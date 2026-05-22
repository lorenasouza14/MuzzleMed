import 'react';
import './CardConsultation.css';

function CardConsultation({ namePet, date, time, symptoms, location, veterinarian }) {
    return (
        <div className='background-card'>
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