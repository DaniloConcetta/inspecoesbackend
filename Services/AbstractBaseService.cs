﻿using Inspecoes.Interfaces;
using Inspecoes.Models;
using Inspecoes.Notifications;
using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Inspecoes.Services
{
    public abstract class AbstractBaseService<TEntity> : IService<TEntity> where TEntity : Entity
    {
        private readonly INotifier _notifier;
        private readonly IAbstractRepository<TEntity> _repository;
        protected AbstractBaseService(INotifier notifier, IAbstractRepository<TEntity> repository)
        {
            _notifier = notifier;
            _repository = repository;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage); //023.avi14:32
            }
        }

        protected void Notify(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }

        protected bool RunValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }

        public virtual Task<TEntity> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            return _repository.GetAll();
        }

        protected bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}