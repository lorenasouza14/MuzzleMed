import { useState } from "react";
import FormsInput from "../components/FormsInput/FormsInput";
import LoginButton from "../components/LoginButton/LoginButton";
import "../styles/Login.css";
import logo from '../assets/images/logo.png';

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    return (
        <main className="container">
            <div className="login-container">
                <div className="logo">
                    <img src={logo} alt="Logo" />
                </div>
                <div className="login-left">
                    <div className="login-form-wrapper">
                        <FormsInput
                            label="E-mail"
                            type="email"
                            name="email"
                            placeholder="Seuemail@exemplo.com"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        />
                        <FormsInput
                            label="Senha"
                            type="password"
                            name="password"
                            placeholder="Sua senha"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        />
                        <LoginButton onClick={() => console.log("Login clicked")} />

                        <div className="login-footer">
                            <p>
                                Não possuí conta?{" "}
                                <a href="/novo-usuario" className="login-footer-link">
                                    Criar conta
                                </a>
                            </p>
                        </div>
                    </div>
                </div>

                <div className="login-right">
                    <h2>Vamos continuar salvando rabinhos e ronronados?</h2>
                    <h1>Acesse sua conta!</h1>
                </div>
            </div>
        </main>
    );
}

export default Login;
