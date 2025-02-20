﻿using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        //Iiniciado para evitar referência nula
        private readonly Tarefas _tarefasService;
        // Adicionado um construtor para inicializar a classe Tarefas
        public TarefasController()
        {
            _tarefasService = new Tarefas();
        }

         
        [Authorize]
        [HttpPost("lstTarefas")]
        public ActionResult lstTarefas()
        {
            try
            {
                //Chama a função que preenche e retorna a lista
                var tarefas = _tarefasService.lstTarefas();
                //Retorna a lista e o código 200
                return StatusCode(200, tarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}"});
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {   
                //Chama a função para inserir a tarefa na lista
                _tarefasService.InserirTarefa(request);
                //Chama a função lstTarefas para retornar a lista atualizada
                var tarefas = _tarefasService.lstTarefas(); 
                 //Retorna a lista e o código 200
                return StatusCode(200, tarefas);


            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpGet("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                //Chama a função para remover a tarefa na lista
                _tarefasService.DeletarTarefa(ID_TAREFA);
                //Chama a função lstTarefas para retornar a lista atualizada
                var tarefas = _tarefasService.lstTarefas();
                //Retorna a lista e o código 200
                return StatusCode(200, tarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
