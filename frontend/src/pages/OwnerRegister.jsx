import { useState } from "react";
import FormsInput from "../components/FormsInput/FormsInput";
import "../styles/OwnerRegister.css";
import ButtonSaveCancel from "../components/ButtonSaveCancel/ButtonSaveCancel";
import { useNavigate } from "react-router-dom";
import logo from '../assets/images/logo.png';
import { createUser } from "../services/routes/user";

function OwnerRegister() {

    const navigate = useNavigate();

    const [dateOfBirth, setDateOfBirth] = useState("");
    const [fullName, setName] = useState("");
    const [email, setEmail] = useState("");
    const [cpf, setCpf] = useState("");
    const [phone, setPhone] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");

    const handleSave = async () => {
        if (password !== confirmPassword) {
            alert("As senhas não coincidem. Por favor, tente novamente.");
            return;
        }
        try {
            const newUser = {
                fullName,
                email,
                cpf,
                phone,
                dateOfBirth,
                password
            };
            console.log("Dados do usuário:", newUser);
            await createUser(newUser);
            alert("Usuário cadastrado com sucesso!");
            navigate("/");
            
        } catch (error) {
            console.error("Erro ao criar usuário:", error);
            alert("Erro ao cadastrar usuário. Por favor, tente novamente.");
        }
    };

    return (
        <main className="container">
            <div className="register-container">

                <div className="logo">
                    <img src={logo} alt="Logo" />
                </div>

                <div className="register-left">
                    <h1>Cadastre-se</h1>
                </div>


                <div className="register-right">
                    <div className="register-form-wrapper">
                        <FormsInput
                            label="Nome Completo"
                            type="text"
                            name="name"
                            placeholder="Digite seu nome completo"
                            value={fullName}
                            onChange={(e) => setName(e.target.value)}
                        />
                        <FormsInput
                            label="E-mail"
                            type="email"
                            name="email"
                            placeholder="Digite seu e-mail"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        />
                        <div className="register-row">

                            <FormsInput
                                label="CPF"
                                type="text"
                                name="cpf"
                                placeholder="123.456.789-10"
                                value={cpf}
                                onChange={(e) => setCpf(e.target.value)}
                            />

                            <FormsInput
                                label="Data de Nascimento"
                                type="date"
                                name="dateOfBirth"
                                placeholder=""
                                value={dateOfBirth}
                                onChange={(e) => setDateOfBirth(e.target.value)}
                            />
                        </div>

                        <FormsInput
                            label="Telefone"
                            type="tel"
                            name="phone"
                            placeholder="(XX) XXXXX-XXXX"
                            value={phone}
                            onChange={(e) => setPhone(e.target.value)}
                        />

                        <div className="register-row">

                            <FormsInput
                                label="Senha"
                                type="password"
                                name="password"
                                placeholder="Digite sua senha"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                            />

                            <FormsInput
                                label="Confirmar Senha"
                                type="password"
                                name="confirmPassword"
                                placeholder="Digite a senha novamente"
                                value={confirmPassword}
                                onChange={(e) => setConfirmPassword(e.target.value)}
                            />
                        </div>

                        <ButtonSaveCancel 
                        onSave={handleSave} 
                        onCancel={() => navigate('/')} 
                        />
                    </div>
                </div>
            </div>
        </main>
    );
}

export default OwnerRegister;