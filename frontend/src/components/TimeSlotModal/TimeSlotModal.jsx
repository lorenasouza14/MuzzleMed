import { useState } from "react";
import "./TimeSlotModal.css";

function TimeSlotModal({ isOpen, onClose, onConfirm, initialSelectedTime }) {
  // Estado local para rastrear qual bolinha o usuário clicou DENTRO da janela
  const [tempTime, setTempTime] = useState(initialSelectedTime);

  const availableTimes = [
    "09:00", "10:00", "11:00", "12:00", 
    "13:00", "14:00", "15:00", "16:00", "17:00"
  ];

  // Se a janela não estiver aberta, não renderiza nada
  if (!isOpen) return null;

  const handleConfirm = () => {
    if (tempTime) {
      onConfirm(tempTime); // Dispara a sua regra de negócio/reserva
      onClose(); // Fecha a janela
    }
  };

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <div className="modal-header">
          <h3>Escolha um Horário</h3>
          <button className="close-btn" onClick={onClose}>&times;</button>
        </div>

        <div className="time-slots-grid">
          {availableTimes.map((time) => (
            <button
              key={time}
              type="button"
              className={`time-slot-button ${tempTime === time ? "active" : ""}`}
              onClick={() => setTempTime(time)}
            >
              {time}
            </button>
          ))}
        </div>

        <div className="modal-actions">
          <button 
            className="confirm-time-btn" 
            disabled={!tempTime} 
            onClick={handleConfirm}
          >
            Confirmar Horário
          </button>
        </div>
      </div>
    </div>
  );
}

export default TimeSlotModal;