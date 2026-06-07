import { useState } from 'react';
import './CardConsultation.css';

function CardConsultation({ namePet, date, time, symptoms, location, veterinarian, onDelete }) {
    const [menuOpen, setMenuOpen] = useState(false);

    return (
        <div className='background-card'>
            {/* Botão de três pontinhos */}
            <div className="card-menu-container">
                <button className="menu-btn" onClick={() => setMenuOpen(!menuOpen)}>
                    ⋮
                </button>
                {menuOpen && (
                    <div className="menu-dropdown">
                        <button className="delete-btn" onClick={() => {
                            onDelete();
                            setMenuOpen(false);
                        }}>
                            Deletar
                        </button>
                    </div>
                )}
            </div>

            <h2>{namePet}</h2>
            
            <div className='row-card'>
                <p><strong>Data:</strong> {date}</p>
                <p><strong>Hora:</strong> {time}</p>
            </div>

            <p><strong>Sintomas:</strong> {symptoms}</p>
            <p><strong>Local:</strong> {location}</p>
            <p><strong>Veterinário:</strong> {veterinarian}</p>
        </div>
    );
}

export default CardConsultation;