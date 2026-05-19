import React, { useState, useEffect } from 'react';
import './PetTable.css'; 
import { LuTrash, LuPencil} from 'react-icons/lu';

const PetTable = () => {

    const [appointments, setAppointments] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const mockData = [
            { id: 1, nome: 'Pituffinha Santos', especie: 'Gato', raca: 'SRD', dataNascimento: '05/03/2023', genero: 'Masculino' },
            { id: 2, nome: 'Panetone Santos', especie: 'Gato', raca: 'SRD', dataNascimento: '05/03/2023', genero: 'Feminino' },
            { id: 3, nome: 'Panetone Santos', especie: 'Gato', raca: 'SRD', dataNascimento: '05/03/2023', genero: 'Feminino' }
        ];

        setTimeout(() => {
            setAppointments(mockData);
            setLoading(false);
        }, 1000);
    }, []);

    const handleDelete = (id) => {
        console.log(`Preparando para deletar na API o registro com ID: ${id}`);
        // Futuramente: axios.delete(`/api/consultas/${id}`).then(() => recarregar a lista)
    };

    const handleEdit = (id) => {
        console.log(`Abrir modal de edição para o ID: ${id}`);
    };

    return (
        <div className="table-wrapper">
            <table className="muzzle-table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Nome</th>
                        <th>Espécie</th>
                        <th>Raça</th>
                        <th>Data de Nascimento</th>
                        <th>Gênero</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {loading ? (
                        <tr>
                            <td colSpan="7" style={{ textAlign: 'center', padding: '20px' }}>
                                Buscando fofuras no sistema... 🐾
                            </td>
                        </tr>
                    ) : (

                        appointments.map((pet) => (
                            <tr key={pet.id}>
                                <td>{pet.id}</td>
                                <td>{pet.nome}</td>
                                <td>{pet.especie}</td>
                                <td>{pet.raca}</td>
                                <td>{pet.dataNascimento}</td>
                                <td>{pet.genero}</td>
                                <td className="actions">
                                    <button
                                        className="btn-delete"
                                        onClick={() => handleDelete(pet.id)}
                                        title="Excluir"
                                    >
                                        <LuTrash size={18} style={{color: "var(--rosa-escuro)"}} />
                                    </button>
                                    <button
                                        className="btn-edit"
                                        onClick={() => handleEdit(pet.id)}
                                        title="Editar"
                                    >
                                        <LuPencil size={18} style={{color: "var(--azul-escuro)"}}/>
                                    </button>
                                </td>
                            </tr>
                        ))
                    )}
                </tbody>
            </table>

            <div className="pagination">
                <span className="page-number">1</span>
                <span className="page-number active">2</span>
                <span className="page-number">3</span>
                <span className="dots">...</span>
            </div>
        </div>
    );
};

export default PetTable;