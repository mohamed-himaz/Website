﻿using Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Website.Api.Models.Questions;
using Website.Domain.Abstractions.Repositories;
using Website.Domain.Models;

namespace Website.Api.Controllers
{
	/// <summary>
	/// Представляет API для работы с вопросами.
	/// </summary>
	[Route("[controller]")]
	[ApiController]
	public class QuestionsController : ControllerBase
	{
		private readonly IQuestionRepository _questionRepository;

		public QuestionsController(IQuestionRepository questionRepository)
		{
			_questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
		}

		/// <summary>
		/// Создаёт вопрос.
		/// </summary>
		/// <param name="questionFm">Модель вопроса.</param>
		[HttpPost]
		public Task CreateQuestion(QuestionFm questionFm)
		{
			if (string.IsNullOrEmpty(questionFm.Contact))
				throw new ArgumentException($"{questionFm.Contact} is null or empty.");
			if (string.IsNullOrEmpty(questionFm.Content))
				throw new ArgumentException($"{questionFm.Content} is null or empty.");

			Question question = new Question()
			{
				Id = Guid.NewGuid(),
				Date = DateTime.UtcNow,
				Contact = questionFm.Contact,
				QuestionerName = questionFm.QuestionerName,
				Content = questionFm.Content
			};
			return _questionRepository.CreateQuestionAsync(question);
		}
		/// <summary>
		/// Возвращает модель вопроса.
		/// </summary>
		/// <param name="questionId">Идентификатор вопроса.</param>
		/// <returns>Модель вопроса.</returns>
		[HttpGet("{questionId}")]
		public Task<Question> GetQuestion(Guid questionId) => _questionRepository.GetQuestionAsync(questionId);
		/// <summary>
		/// Возвращает вопросы.
		/// </summary>
		/// <param name="page">Номер страницы.</param>
		/// <param name="count">Количество выгружаемых элементов.</param>
		/// <returns>Вопросы</returns>
		[HttpGet]
		public Task<CollectionResult<Question>> GetQuestions(int page = 1, int count = 10)
		{
			if (page <= 0)
				throw new ArgumentOutOfRangeException(nameof(page));
			if (count < 0)
				throw new ArgumentOutOfRangeException(nameof(count));

			return _questionRepository.GetQuestionsAsync((page - 1) * count, count);
		}
	}
}