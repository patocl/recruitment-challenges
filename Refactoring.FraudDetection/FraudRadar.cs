// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

using Refactoring.FraudDetection.Core.Infrastructure.Repository.Contracts;
using Refactoring.FraudDetection.Service.Contracts;
using System;
using System.Collections.Generic;
using Refactoring.FraudDetection.Core.Infrastructure.Normalizer;
using Refactoring.FraudDetection.Core.Infrastructure.Normalizer.Contracts;
using Refactoring.FraudDetection.Core.Infrastructure.Repository;
using Refactoring.FraudDetection.Models.Contracts;
using Refactoring.FraudDetection.Service;

namespace Refactoring.FraudDetection
{
    public class FraudRadar
    {
        public IFileRepository<IOrder> OrderFileRepository { get; }
        public IAuditor<IOrder, IFraudResult> OrderAuditor { get; }
        public INormalizer<IOrder> Normalizer { get; }

        public FraudRadar()
        {
            OrderFileRepository ??= new OrderFileRepository();
            Normalizer ??= new OrderNormalizer();
            OrderAuditor ??= new OrderAuditorOptimized(); //The old version is OrderAuditor() :D
        }

        public FraudRadar(IFileRepository<IOrder> orderFileRepository) : this() 
            => OrderFileRepository = orderFileRepository ?? throw new ArgumentNullException(nameof(orderFileRepository));

        public FraudRadar(IAuditor<IOrder, IFraudResult> orderAuditor) : this()
            => OrderAuditor = orderAuditor ?? throw new ArgumentNullException(nameof(orderAuditor));

        public FraudRadar(IFileRepository<IOrder> orderFileRepository, IAuditor<IOrder, IFraudResult> orderAuditor)
        {
            OrderFileRepository = orderFileRepository ?? throw new ArgumentNullException(nameof(orderFileRepository));
            OrderAuditor = orderAuditor ?? throw new ArgumentNullException(nameof(orderAuditor));
        }

        public IEnumerable<IFraudResult> Check(IFileReader fileReader)
            => OrderAuditor.Analyze(Normalizer.Apply(OrderFileRepository.GetAll(fileReader)));
    }
}