import { useState } from "react";
import FormsInput from "../FormsInput/FormsInput";
import ButtonSaveCancel from "../ButtonSaveCancel/ButtonSaveCancel";
import ToggleInput from "../ToggleInput/ToggleInput";
import "./PetForms.css";
import { createPet } from "../../services/routes/pet";
import Swal from "sweetalert2"; 

function PetForms({ onSave, onCancel }) {
    const [name, setName] = useState("");
    const [specie, setSpecie] = useState("Dog"); 
    const [breed, setBreed] = useState("");
    const [dateOfBirth, setDateOfBirth] = useState("");
    const [gender, setGender] = useState("Male"); 

    const handleSave = async () => {
        if (!name.trim()) {
            Swal.fire({
                title: "Campo obrigatório",
                text: "Por favor, insira o nome do pet.",
                icon: "warning",
                confirmButtonColor: "var(--azul-escuro)"
            });
            return;
        }

        try {
            const newPet = {
                name,
                specie,
                breed,
                dateOfBirth,
                gender,
                descriptionSymtoms: "Nenhum sintoma descrito", 
            };

            console.log("JSON enviado para a API:", JSON.stringify(newPet));
            await createPet(newPet);

            // 🎉 Pop-up de sucesso antes de fechar ou redirecionar
            Swal.fire({
                title: 'Cadastrado com sucesso!',
                text: `${name} foi adicionado aos seus pets.`,
                icon: 'success',
                confirmButtonColor: 'var(--azul-escuro)'
            }).then(() => {
                // Executa o onSave do componente pai apenas após o usuário fechar o alerta
                if (onSave) onSave();
            });

        } catch (error) {
            console.error("Erro ao salvar pet:", error);
            
            // Pop-up de erro caso a API falhe
            Swal.fire({
                title: 'Erro ao cadastrar',
                text: error.response?.data?.message || 'Não foi possível salvar o pet no momento. Tente novamente.',
                icon: 'error',
                confirmButtonColor: 'var(--rosa-escuro)'
            });
        }
    };

    return (
        <main className="container">
            <FormsInput
                label="Nome"
                type="text"
                name="name"
                placeholder="Nome do pet"
                value={name}
                onChange={(e) => setName(e.target.value)}
            />

            <div className="pet-row">
                <ToggleInput
                    label="Espécie"
                    options={[
                        { label: "Dog", value: "Dog" },
                        { label: "Cat", value: "Cat" }
                    ]}
                    value={specie}
                    onChange={setSpecie}
                />

                <FormsInput
                    label="Raça"
                    type="text"
                    name="breed"
                    placeholder="Pastor Alemão"
                    value={breed}
                    onChange={(e) => setBreed(e.target.value)}
                />
            </div>

            <div className="pet-row" >
                <FormsInput
                    label="Data de Nascimento"
                    type="date"
                    name="dateOfBirth"
                    placeholder=""
                    value={dateOfBirth}
                    onChange={(e) => setDateOfBirth(e.target.value)}
                />

                <ToggleInput
                    label="Gênero"
                    options={[
                        { label: "Male", value: "Male" },
                        { label: "Female", value: "Female" }
                    ]}
                    value={gender}
                    onChange={setGender}
                />
            </div>
            
            <div style={{ display: "flex", justifyContent: "center", alignItems: "center" }}>
                <div style={{ width: "50%", marginTop: "50px" }} >
                    <ButtonSaveCancel onSave={handleSave} onCancel={onCancel} />
                </div>
            </div>
        </main>
    );
}

export default PetForms;