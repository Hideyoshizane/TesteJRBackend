using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                List<TarefaDTO> lstTarefas = new List<TarefaDTO>();

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 1,
                    DS_TAREFA = "Fazer Compras"
                });

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 2,
                    DS_TAREFA = "Fazer Atividade Faculdade"
                });

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 3,
                    DS_TAREFA = "Subir Projeto de Teste no GitHub"
                });

                //Retorna a lista criada em vez de uma lista vazia
                //return new List<TarefaDTO>();
                return lstTarefas;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public void InserirTarefa(TarefaDTO Request)
        {
            try
            {
                List<TarefaDTO> lstResponse = lstTarefas();
                lstResponse.Add(Request);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                 // Recupera a lista de tarefas
                List<TarefaDTO> lstResponse = lstTarefas();

                // Procura a tarefa com o ID especificado.
                var Tarefa = lstResponse.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);

                //Adicionado uma verificação para evitar erro de referência caso a tarefa não seja encontrada.
                if (Tarefa != null)
                {
                    // Se a tarefa for encontrada, remove da lista
                    lstResponse.Remove(Tarefa);
                } 
                else
                {
                    // Caso a tarefa não seja encontrada, lança uma exceção com uma mensagem amigável
                    throw new Exception($"Tarefa com ID {ID_TAREFA} não encontrada.");
                }
            }
            catch(Exception ex)
            {
               throw new Exception($"Erro ao tentar deletar a tarefa com ID {ID_TAREFA}: {ex.Message}", ex);
            }
        }
    }
}
