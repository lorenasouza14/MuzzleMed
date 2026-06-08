import './BranchList.css';
import homeCatImg from '/src/assets/images/Home-cat.png';
import { useState, useEffect } from 'react';
import Modal from '../Modal/Modal';
import ScheduleForms from '../ScheduleForms/ScheduleForms';
import { getClinics } from '../../services/routes/clinic';
import { getPets } from '../../services/routes/pet'; // <--- IMPORTADO GETPETS
import { useNavigate } from 'react-router-dom'; // <--- IMPORTADO NAVIGATE
import Swal from 'sweetalert2'; // <--- IMPORTADO SWEETALERT

function BranchList() {
    const [isModalOpen, setModalOpen] = useState(false);
    const [clinics, setClinics] = useState([]);
    
    const navigate = useNavigate(); // <--- INICIALIZADO O REDIRECIONAMENTO

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

    // FUNÇÃO QUE VALIDA OS PETS ANTES DE ABRIR O MODAL
    const handleScheduleClick = async () => {
        try {
            const petsData = await getPets();
            const petsArray = Array.isArray(petsData) ? petsData : [];

            if (petsArray.length === 0) {
                // Se não tiver pets, bloqueia o modal e avisa usando o SweetAlert
                Swal.fire({
                    title: 'Atenção!',
                    text: 'Você não possui nenhum pet cadastrado. Para agendar uma consulta, cadastre um pet primeiro.',
                    icon: 'warning',
                    confirmButtonText: 'Cadastrar Pet',
                    confirmButtonColor: '#1890ff',
                    allowOutsideClick: false
                }).then((result) => {
                    if (result.isConfirmed) {
                        navigate('/pets'); // Redireciona o usuário
                    }
                });
            } else {
                // Se tiver pelo menos um pet cadastrado, abre o modal normalmente
                setModalOpen(true);
            }
        } catch (error) {
            console.error("Erro ao verificar pets:", error);
            // Caso dê algum erro na API dos pets, abre por segurança ou trate como preferir
            setModalOpen(true);
        }
    };

    return (
        <aside className="branch-sidebar">
            <div className="branch-container">
                <h2 className="branch-title">Conheça nossas Unidades</h2>
                <ul className="branch-list">
                    {clinics.map((clinic) => (
                        <li key={clinic.id} className="branch-item">
                            <div className="branch-marker-info">
                                <span className="pin-icon">📍</span>
                                <strong className='color-branch'>{clinic.name}</strong>
                            </div>
                            <div className="branch-address">
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
                        onClick={handleScheduleClick} // <--- TROCADO PARA A FUNÇÃO DE VALIDAÇÃO
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