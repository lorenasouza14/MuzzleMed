import React from "react";
import "./ToggleInput.css";

function ToggleInput({ label, options, value, onChange }) {
    return (
        <div className="toggle-input">
            {label && (
                <label className="toggle-input-label">
                    {label}
                </label>
            )}
            
            <div className="toggle-input-wrapper">
                {options.map((option) => (
                    <button
                        key={option.value}
                        type="button"
                        className={`toggle-btn ${value === option.value ? "active" : ""}`}
                        onClick={() => onChange(option.value)}
                    >
                        {option.label}
                    </button>
                ))}
            </div>
        </div>
    );
}

export default ToggleInput;