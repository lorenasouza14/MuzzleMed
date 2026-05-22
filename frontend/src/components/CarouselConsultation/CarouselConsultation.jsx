import { useState } from "react";
import CardConsultation from "../CardConsultation/CardConsultation";
import './CarouselConsultation.css';

function CarouselConsultation({ consultations }) {
    const [currentIndex, setCurrentIndex] = useState(0);
    const cardsPerPage = 2;

    // Calcula o limite máximo que o carrossel pode avançar
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

    // Cada avanço desloca a largura de 1 card + o gap entre eles (calculado no CSS)
    // Usando 50% porque são 2 cards por tela (cada um ocupa quase 50%)
    const translateXValue = currentIndex * (100 / cardsPerPage);

    return (
        <div className="carousel-container-wrapper">
            {/* Botão Esquerdo */}
            <button 
                className="carousel-arrow" 
                onClick={prevSlide} 
                disabled={currentIndex === 0}
            >
                ‹
            </button>

            {/* Janela que esconde o que transborda */}
            <div className="carousel-window">
                {/* A faixa que desliza de verdade */}
                <div 
                    className="carousel-track"
                    style={{ transform: `translateX(-${translateXValue}%)` }}
                >
                    {consultations.map((consultation, index) => (
                        <div className="carousel-item" key={index}>
                            <CardConsultation 
                                namePet={consultation.namePet}
                                date={consultation.date}
                                time={consultation.time}
                                symptoms={consultation.symptoms}
                                location={consultation.location}
                                veterinarian={consultation.veterinarian}
                            />
                        </div>
                    ))}
                </div>
            </div>

            {/* Botão Direito */}
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