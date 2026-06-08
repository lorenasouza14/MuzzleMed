import { useState } from 'react';
import './CardConsultation.css';

function CardConsultation({ id, namePet, date, time, symptoms, location, veterinarian, onDelete }) {
    const [menuOpen, setMenuOpen] = useState(false);

    return (
        <div className='background-card'>
            <div className="card-menu-container">
                <button className="menu-btn" onClick={() => setMenuOpen(!menuOpen)}>
                    ⋮
                </button>
                {menuOpen && (
                    <div className="menu-dropdown">
                        <button className="delete-btn" onClick={() => {
                            onDelete(id); 
                            setMenuOpen(false);
                        }}>
                            Cancelar
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