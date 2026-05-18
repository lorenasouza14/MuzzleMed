import React from "react";
import "./Title.css";
import { LuX } from "react-icons/lu";

function Title({ 
    title, 
    botao, 
    onButtonClick,  
    onCloseClick,   
    showButton, 
    showCloseButton 
}) {
    return (
        <div className="titulo-botao">
            <h1>{title}</h1>
            <div className="botoes-wrapper">
                {showButton && (
                    <button className="botao" onClick={onButtonClick}>
                        {botao}
                    </button>
                )}
                
                {showCloseButton && (
                    <button className="btn-fechar" onClick={onCloseClick} aria-label="Fechar">
                        <LuX size={24} />
                    </button>
                )}
            </div>
        </div>
    );
}

export default Title;