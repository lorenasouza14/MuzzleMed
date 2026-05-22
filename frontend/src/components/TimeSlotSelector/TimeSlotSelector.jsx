import { useState } from "react";
import TimeSlotModal from "../TimeSlotModal/TimeSlotModal";
import "./TimeSlotSelector.css";

function TimeSlotSelector({ label, selectedTime, onTimeChange, isDateSelected, dateSchedule }) {
  const [isModalOpen, setIsModalOpen] = useState(false);

  // Valida se a data selecionada é menor que amanhã
  const isDateInvalid = () => {
    if (!dateSchedule) return true;

    // Criamos a data de amanhã zerando as horas para comparar apenas os dias
    const tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);
    tomorrow.setHours(0, 0, 0, 0);

    // O input date retorna no fuso local, adicionamos o replace para evitar problemas de fuso
    const selected = new Date(dateSchedule + "T00:00:00");

    return selected < tomorrow;
  };

  // O botão só deve ser liberado se houver data selecionada E ela for válida (de amanhã em diante)
  const isButtonDisabled = !isDateSelected || isDateInvalid();

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
        {selectedTime ? `Horário: ${selectedTime}` : "Selecionar Horário"}
      </button>

      {!isDateSelected && (
        <span className="date-warning-text">Selecione a data primeiro</span>
      )}

      {isDateSelected && isDateInvalid() && (
        <span className="date-warning-text" style={{ color: "red" }}>A data deve ser a partir de amanhã</span>
      )}

      {/* Janelinha de horários */}
      <TimeSlotModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        initialSelectedTime={selectedTime}
        onConfirm={(time) => {
          onTimeChange(time);
          console.log(`Regra de negócio: Reservando o horário ${time}`);
        }}
      />
    </div>
  );
}

export default TimeSlotSelector;