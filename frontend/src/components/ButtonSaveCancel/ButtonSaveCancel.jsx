import React, { useState } from "react";
import './ButtonSaveCancel.css';

function ButtonSaveCancel({ onSave, onCancel }) {   
    return (
        <div className="button-container">
            <button className="save-button" onClick={onSave}>Salvar</button>
            <button className="cancel-button" onClick={onCancel}>Cancelar</button>
        </div>
    );
}

export default ButtonSaveCancel;