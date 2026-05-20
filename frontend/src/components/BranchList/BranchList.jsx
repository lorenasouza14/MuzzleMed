import 'react';
import './BranchList.css';

function BranchList() {
    const branches = [
        { id: 1, city: "São Carlos", address: "Rua Maurício Neves - 1035", neighborhood: "Bairro Jaraguá" },
        { id: 2, city: "Campinas", address: "Rua Maurício Neves - 1035", neighborhood: "Bairro Jaraguá" },
        { id: 3, city: "Bauru", address: "Rua Maurício Neves - 1035", neighborhood: "Bairro Jaraguá" },
        { id: 4, city: "São Paulo", address: "Rua Maurício Neves - 1035", neighborhood: "Bairro Jaraguá" },
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
                    <img src="/src/assets/images/Home-cat.png" alt="Gatinho com estetoscópio" className="promo-img" />
                    <button className="btn-schedule">Agendar Consulta</button>
                </div>
            </div>
        </aside>
    );
}

export default BranchList;