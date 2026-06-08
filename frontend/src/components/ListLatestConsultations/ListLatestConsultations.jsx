import 'react';
import './ListLatestConsultations.css';
import { HiMapPin } from "react-icons/hi2";

function ListLatestConsultations({namePet, dateConsultation, symptoms, medication, location, veterinarian, status}) {
    return (
        <div className='card-history-lt'>
            <div className="row-header-lt">
                <h2 className="pet-name-lt">{namePet}</h2>
                <div className="status-date-lt">
                    <span className="status-text">{status}</span>
                    <span className="date-text">{dateConsultation}</span>
                </div>
            </div>

            <div className="body-history-lt">
                <div className="info-block-lt">
                    <p><strong>Diagnostico:</strong></p>
                    <p className="desc-text">{symptoms}</p>
                </div>
                <div className="info-block-lt">
                    <p><strong>Medicação:</strong></p>
                    <p className="desc-text"> {medication}</p>
                </div>
            </div>
            
            <div className="row-footer-lt">
                <span> <HiMapPin color="var(--rosa-escuro)" /> {location}</span>
                <span>• <strong>Doutor:</strong> {veterinarian}</span>
            </div>
        </div>
    );
}
export default ListLatestConsultations;
