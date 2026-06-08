import "./TextareaButton.css";

function TextareaButton({ label, name, value, placeholder, onChange }) {
    return (
        <div className="forms-input">
            <label htmlFor={name} className="forms-input-label">
                {label}
            </label>
            
            <div className="forms-input-wrapper">
                <textarea 
                    className="forms-input-field"
                    id={name}
                    name={name}
                    value={value}
                    placeholder={placeholder}
                    onChange={onChange}
                    rows="4" // Define a altura inicial do campo
                    style={{ resize: "vertical" }} // Permite que o usuário ajuste a altura
                />
            </div>
        </div>
    );
}

export default TextareaButton;