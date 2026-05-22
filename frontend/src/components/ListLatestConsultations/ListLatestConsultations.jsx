// import 'react';
// import './ListLatestConsultations.css';


// function ListLatestConsultations({namePet, dateConsultation, symptoms, medication, location, veterinarian, status}) {
//     return (
//         <div className='card-history-lt'>
//             <div className="row-header-lt">
//                 <h2>{namePet}</h2>
//                 <p>{status}<br/>{dateConsultation}</p>
//             </div>

//             <div className="row-consultation-history-lt">
//                 <p><strong>Diagnostico</strong></p>
//                 <p><strong>Medicação:</strong></p>
//             </div>
//             <div className="row-consultation-history-lt">
//                 <p>{symptoms}</p>
//                 <p>{medication}</p>
//             </div>
//             <div className="row-locale-lt">
//                 <i className="fas fa-map-marker-alt"></i>
//                 <p>{location}</p>
//                 <p>{veterinarian}</p>
//             </div>
//         </div>
//     );
// }
// export default ListLatestConsultations;

import 'react';
import './ListLatestConsultations.css';

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
                    <p className="desc-text">• {medication}</p>
                </div>
            </div>
            
            <div className="row-footer-lt">
                <span>📍 {location}</span>
                <span>• <strong>Doutor:</strong> {veterinarian}</span>
            </div>
        </div>
    );
}
export default ListLatestConsultations;
