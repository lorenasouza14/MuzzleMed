import React, { useState } from "react";
import "./FormsInput.css";
import { LuEye, LuEyeClosed } from "react-icons/lu"; 

function FormsInput({ label, type, name, value, placeholder, onChange }) {
    const [showPassword, setShowPassword] = useState(false);
    const inputType = type === 'password' && showPassword ? 'text' : type;

    const togglePasswordVisibility = () => {
        setShowPassword(!showPassword);
    };

    return (
        <div className="forms-input">
            <label htmlFor={name} className="forms-input-label">
                {label}
            </label>
            
            <div className="forms-input-wrapper">
                <input 
                    className="forms-input-field"
                    type={inputType}
                    id={name}
                    name={name}
                    value={value}
                    placeholder={placeholder}
                    onChange={onChange}
                />
                
                {type === 'password' && (
                    <button
                        type="button"
                        className="toggle-password-btn"
                        onClick={togglePasswordVisibility}
                        aria-label={showPassword ? "Esconder senha" : "Mostrar senha"}
                    >

                        {showPassword ? <LuEye size={20} /> : <LuEyeClosed size={20} />}
                    </button>
                )}
            </div>
        </div>
    );
}

export default FormsInput;