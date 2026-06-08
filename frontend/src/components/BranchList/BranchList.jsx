
import './BranchList.css';
import homeCatImg from '/src/assets/images/Home-cat.png';
import { useState, useEffect } from 'react';
import Modal from '../Modal/Modal';
import ScheduleForms from '../ScheduleForms/ScheduleForms';
import { getClinics } from '../../services/routes/clinic';

function BranchList() {
    const [isModalOpen, setModalOpen] = useState(false);
    const [clinics, setClinics] = useState([]);

    useEffect(() => {
        const fetchClinics = async () => {
            try {
                const data = await getClinics();
                setClinics(Array.isArray(data) ? data : []);
            } catch (error) {
                console.error("Erro ao carregar clínicas:", error);
            }
        };

        fetchClinics();
    }, []);

    return (
        <aside className="branch-sidebar">
            <div className="branch-container">
                <h2 className="branch-title">Conheça nossas Unidades</h2>
                <ul className="branch-list">
                    {clinics.map((clinic) => (
                        <li key={clinic.id} className="branch-item">
                            <div className="branch-marker-info">
                                <span className="pin-icon">📍</span>
                                {/* Verifique se o nome dos campos no back-end são exatamente 'city' e 'address' */}
                                <strong className='color-branch'>{clinic.name}</strong>
                            </div>
                            <div className="branch-address">
                                {/* <p>{clinic.address}</p> */}
                                <p className="sub-addr">{clinic.address}</p>
                            </div>
                        </li>
                    ))}
                </ul>
                
                <div className='promo-banner'>
                    <h3>Não deixe seu pet na mão</h3>
                    <p>Cuide de quem você mais ama!</p>
                    <img src={homeCatImg} alt="Gatinho com estetoscópio" className="promo-img" />

                    <button
                        className="btn-schedule"
                        onClick={() => setModalOpen(true)}
                    >
                        Agendar Nova Consulta
                    </button>
                </div>
            </div>

            <Modal
                title={"Agendar Consulta"}
                isOpen={isModalOpen}
                onClose={() => setModalOpen(false)}
            >
                <ScheduleForms 
                    onSave={() => setModalOpen(false)} 
                    onCancel={() => setModalOpen(false)} 
                />
            </Modal>
        </aside>
    );
}

export default BranchList;