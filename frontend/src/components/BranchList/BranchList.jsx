import 'react';
import './BranchList.css';
import homeCatImg from '/src/assets/images/Home-cat.png';
import { useState } from 'react';
import Modal from '../Modal/Modal';
import ScheduleForms from '../ScheduleForms/ScheduleForms';

function BranchList() {
    const [isModalOpen, setModalOpen] = useState(false);



    const branches = [
        { id: 1, city: "São Carlos", address: "Rua Maurício Neves - 1035", neighborhood: "Bairro Jaraguá" },
        { id: 2, city: "Campinas", address: "Rua Maurício Neves - 1035", neighborhood: "Bairro Jaraguá" },
        { id: 3, city: "Bauru", address: "Rua Maurício Neves - 1035", neighborhood: "Bairro Jaraguá" },

    ];

    return (
        <aside className="branch-sidebar">
            <div className="branch-container">
                <h2 className="branch-title">Conheça nossas Unidades</h2>
                <ul className="branch-list">
                    {branches.map(branch => (
                        <li key={branch.id} className="branch-item">
                            <div className="branch-marker-info">
                                <span className="pin-icon">📍</span>
                                <strong className='color-branch'>{branch.city}</strong>
                            </div>
                            <div className="branch-address">
                                <p>{branch.address}</p>
                                <p className="sub-addr">{branch.neighborhood}</p>
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
                onClose={() => setModalOpen(false)}>
                <ScheduleForms onSave={() => setModalOpen(false)} onCancel={() => setModalOpen(false)} />
            </Modal>
        </aside>
    );
}

export default BranchList;