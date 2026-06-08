import { useState } from "react";
import CardConsultation from "../CardConsultation/CardConsultation";
import './CarouselConsultation.css';

function CarouselConsultation({ consultations, onCancelAppointment }) {
    const [currentIndex, setCurrentIndex] = useState(0);
    const cardsPerPage = 2;

    const maxIndex = Math.max(0, consultations.length - cardsPerPage);

    const nextSlide = () => {
        if (currentIndex < maxIndex) {
            setCurrentIndex(currentIndex + 1);
        }
    };

    const prevSlide = () => {
        if (currentIndex > 0) {
            setCurrentIndex(currentIndex - 1);
        }
    };

    const translateXValue = currentIndex * (100 / cardsPerPage);

    return (
        <div className="carousel-container-wrapper">
            <button 
                className="carousel-arrow" 
                onClick={prevSlide} 
                disabled={currentIndex === 0}
            >
                ‹
            </button>

            <div className="carousel-window">
                <div 
                    className="carousel-track"
                    style={{ transform: `translateX(-${translateXValue}%)` }}
                >
                    {consultations.map((consultation, index) => (
                        <div className="carousel-item" key={index}>
                            <CardConsultation 
                                id={consultation.id}
                                namePet={consultation.namePet}
                                date={consultation.date}
                                time={consultation.time}
                                symptoms={consultation.symptoms}
                                location={consultation.location}
                                veterinarian={consultation.veterinarian}
                                onDelete={onCancelAppointment}
                            />
                        </div>
                    ))}
                </div>
            </div>

            <button 
                className="carousel-arrow" 
                onClick={nextSlide} 
                disabled={currentIndex >= maxIndex}
            >
                ›
            </button>
        </div>
    );
}

export default CarouselConsultation;