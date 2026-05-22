import { useState } from "react";
import "./DropdownButton.css";
// Tornamos as props genéricas: 
// - label: O texto que aparece em cima do select
// - options: A lista de dados que você quer renderizar
// - onSelectData: A função que avisa o componente pai qual item foi escolhido
// - defaultOptionText: O texto inicial (ex: "-- Selecione uma unidade --")
function DropdownButton({ label, options = [], onSelectData, defaultOptionText = "-- Selecione --" }) {
  const [selectedValue, setSelectedValue] = useState("");

  const handleChange = (e) => {
    const value = e.target.value;
    setSelectedValue(value);
    if (onSelectData) onSelectData(value); 
  };

  return (
    <div className="input-group">
      <label>{label}</label>
      
      <select 
      className="selected-button"
        id="dynamic-select"
        value={selectedValue} 
        onChange={handleChange}
        required
      >
        <option value="">{defaultOptionText}</option>
        
        {/* Mapeia a lista genérica que veio por prop */}
        {options.map((option) => (
          <option key={option.id} value={option.id}>
            {option.name}
          </option>
        ))}
      </select>
    </div>
  );
}

export default DropdownButton;