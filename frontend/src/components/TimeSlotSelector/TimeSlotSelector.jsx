import { useState } from "react";
import TimeSlotModal from "../TimeSlotModal/TimeSlotModal";
import { bookTime } from "../../services/routes/reservarhorario"; 
import "./TimeSlotSelector.css";

function TimeSlotSelector({ label, selectedTime, onTimeChange, isDateSelected, dateSchedule }) {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [isLoading, setIsLoading] = useState(false); 

  const isDateInvalid = () => {
    if (!dateSchedule) return true;

    const tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);
    tomorrow.setHours(0, 0, 0, 0);

    const selected = new Date(dateSchedule + "T00:00:00");

    return selected < tomorrow;
  };

  const isButtonDisabled = !isDateSelected || isDateInvalid() || isLoading;

  const handleConfirmTime = async (time) => {
    setIsLoading(true);
    
    const scheduleData = {
      dateSchedule: dateSchedule,
      timeSchedule: time
    };

    try {
      const response = await bookTime(scheduleData);

      onTimeChange(time);
      setIsModalOpen(false);
      
      alert(response.message || "Horário pré-reservado com sucesso!");
    } catch (error) {
      
      const apiMessage = error.response?.data?.message || "Erro ao tentar reservar o horário. Tente novamente.";
      alert(apiMessage);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="time-selector-container">
      <label className="time-selector-label">{label}</label>
      
      <button
        type="button"
        className="open-modal-btn"
        onClick={() => {
          if (!isButtonDisabled) {
            setIsModalOpen(true);
          }
        }}
        disabled={isButtonDisabled}
        style={{
          borderColor: "#ff5376",
          color: isButtonDisabled ? "#999" : "#ff5376",
          fontSize: "14px",
          cursor: isButtonDisabled ? "not-allowed" : "pointer"
        }}
      >
        {isLoading ? "Salvando..." : selectedTime ? `Horário: ${selectedTime}` : "Selecionar Horário"}
      </button>

      {!isDateSelected && (
        <span className="date-warning-text">Selecione a data primeiro</span>
      )}

      {isDateSelected && isDateInvalid() && (
        <span className="date-warning-text" style={{ color: "red" }}>A data deve ser a partir de amanhã</span>
      )}

      
      <TimeSlotModal
        isOpen={isModalOpen}
        onClose={() => !isLoading && setIsModalOpen(false)} 
        initialSelectedTime={selectedTime}
        onConfirm={handleConfirmTime} 
      />
    </div>
  );
}

export default TimeSlotSelector;