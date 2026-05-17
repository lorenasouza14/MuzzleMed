import React, { useState } from "react";
import "./LoginButton.css";

function LoginButton({ onClick }) {
    return (
        <button className="login-button" onClick={onClick}>
            Entrar
        </button>
    );
}

export default LoginButton;