using System;
using System.Collections.Generic;
using System.Linq;
using DynamicExpression.Entities;
using DynamicExpression.Enums;
using DynamicExpression.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicExpression.Test.Extensions;

[TestClass]
public class QueryableExtensionsTest
{
    public class OrderType<T>
    {
        public virtual T Order { get; set; }
    }

    public class Nested<T>
    {
        public virtual string Name { get; set; }
        public virtual OrderType<T> OrderType { get; set; }
    }

    [TestMethod]
    public void OrderWhenGuidTest()
    {
        var list = new[]
        {
            new OrderType<Guid> { Order = Guid.Parse("fdb28f72-e4bd-4ff1-8e20-799daf045ae8") },
            new OrderType<Guid> { Order = Guid.Parse("55882908-85e0-4a89-808e-78044ba355e9") }
        };

        var ordering = new Ordering
        {
            By = "Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering);

        Assert.AreEqual(list[0].Order, orderedList.Last().Order);
        Assert.AreEqual(list[1].Order, orderedList.First().Order);
    }

    [TestMethod]
    public void OrderWhenTimeSpanTest()
    {
        var list = new[]
        {
            new OrderType<TimeSpan> { Order = new TimeSpan(2, 2, 2) },
            new OrderType<TimeSpan> { Order = new TimeSpan(1, 1, 1) }
        };

        var ordering = new Ordering
        {
            By = "Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering);

        Assert.AreEqual(list[0].Order, orderedList.Last().Order);
        Assert.AreEqual(list[1].Order, orderedList.First().Order);
    }

    [TestMethod]
    public void OrderWhenDateTimeTest()
    {
        var list = new[]
        {
            new OrderType<DateTime> { Order = new DateTime(2, 2, 2) },
            new OrderType<DateTime> { Order = new DateTime(1, 1, 1) }
        };

        var ordering = new Ordering
        {
            By = "Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering);

        Assert.AreEqual(list[0].Order, orderedList.Last().Order);
        Assert.AreEqual(list[1].Order, orderedList.First().Order);
    }

    [TestMethod]
    public void OrderWhenDateTimeOffsetTest()
    {
        var list = new[]
        {
            new OrderType<DateTimeOffset> { Order = new DateTimeOffset(2, 2, 2, 2, 2, 2, TimeSpan.Zero) },
            new OrderType<DateTimeOffset> { Order = new DateTimeOffset(1, 1, 1, 1, 1, 1, TimeSpan.Zero) }
        };

        var ordering = new Ordering
        {
            By = "Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering);

        Assert.AreEqual(list[0].Order, orderedList.Last().Order);
        Assert.AreEqual(list[1].Order, orderedList.First().Order);
    }

    [TestMethod]
    public void OrderWhenIntegerTest()
    {
        var list = new[]
        {
            new OrderType<int> { Order = 2 },
            new OrderType<int> { Order = 1 }
        };

        var ordering = new Ordering
        {
            By = "Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering);

        Assert.AreEqual(list[0].Order, orderedList.Last().Order);
        Assert.AreEqual(list[1].Order, orderedList.First().Order);
    }

    [TestMethod]
    public void OrderWhenLongTest()
    {
        var list = new[]
        {
            new OrderType<long> { Order = 2L },
            new OrderType<long> { Order = 1L }
        };

        var ordering = new Ordering
        {
            By = "Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering);

        Assert.AreEqual(list[0].Order, orderedList.Last().Order);
        Assert.AreEqual(list[1].Order, orderedList.First().Order);
    }

    [TestMethod]
    public void OrderWhenFloatTest()
    {
        var list = new[]
        {
            new OrderType<float> { Order = 1.2F },
            new OrderType<float> { Order = 1.1F }
        };

        var ordering = new Ordering
        {
            By = "Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering);

        Assert.AreEqual(list[0].Order, orderedList.Last().Order);
        Assert.AreEqual(list[1].Order, orderedList.First().Order);
    }

    [TestMethod]
    public void OrderWhenDoubleTest()
    {
        var list = new[]
        {
            new OrderType<double> { Order = 1.2D },
            new OrderType<double> { Order = 1.1D }
        };

        var ordering = new Ordering
        {
            By = "Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering);

        Assert.AreEqual(list[0].Order, orderedList.Last().Order);
        Assert.AreEqual(list[1].Order, orderedList.First().Order);
    }

    [TestMethod]
    public void OrderWhenDecimalTest()
    {
        var list = new[]
        {
            new OrderType<decimal> { Order = 1.2M },
            new OrderType<decimal> { Order = 1.1M }
        };

        var ordering = new Ordering
        {
            By = "Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering);

        Assert.AreEqual(list[0].Order, orderedList.Last().Order);
        Assert.AreEqual(list[1].Order, orderedList.First().Order);
    }

    [TestMethod]
    public void OrderWhenBoolTest()
    {
        var list = new[]
        {
            new OrderType<bool> { Order = true },
            new OrderType<bool> { Order = false }
        };

        var ordering = new Ordering
        {
            By = "Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering);

        Assert.AreEqual(list[0].Order, orderedList.Last().Order);
        Assert.AreEqual(list[1].Order, orderedList.First().Order);
    }

    [TestMethod]
    public void OrderWhenEnumTest()
    {
        var list = new[]
        {
            new OrderType<DayOfWeek> { Order = DayOfWeek.Friday },
            new OrderType<DayOfWeek> { Order = DayOfWeek.Monday }
        };

        var ordering = new Ordering
        {
            By = "Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering);

        Assert.AreEqual(list[0].Order, orderedList.Last().Order);
        Assert.AreEqual(list[1].Order, orderedList.First().Order);
    }

    [TestMethod]
    public void OrderWhenEnumNullableTest()
    {
        var list = new[]
        {
            new OrderType<DayOfWeek?> { Order = DayOfWeek.Friday },
            new OrderType<DayOfWeek?> { Order = null }
        };

        var ordering = new Ordering
        {
            By = "Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering);

        Assert.AreEqual(list[0].Order, orderedList.Last().Order);
        Assert.AreEqual(list[1].Order, orderedList.First().Order);
    }

    [TestMethod]
    public void LimitWhenBoolTest()
    {
        var list = new[]
        {
            new object(),
            new object(),
            new object()
        };

        var pagination = new Pagination
        {
            Count = 2,
            Number = 1
        };

        var limittedist = list
            .AsQueryable()
            .Limit(pagination);

        Assert.AreEqual(2, limittedist.Count());
    }

    [TestMethod]
    public void OrderWhenNestedObjectTest()
    {
        var list = new List<Nested<int>>
        {
            new()
            {
                OrderType = new OrderType<int>
                {
                    Order = 11
                }
            },
            new()
            {
                OrderType = new OrderType<int>
                {
                    Order = 4
                }
            },
            new()
            {
                OrderType = new OrderType<int>
                {
                    Order = 8
                }
            },
            new()
            {
                OrderType = new OrderType<int>
                {
                    Order = 2
                }
            }
        };

        var ordering = new Ordering
        {
            By = "OrderType.Order",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering)
            .ToArray();

        Assert.AreEqual(list[3].OrderType.Order, orderedList[0].OrderType.Order);
        Assert.AreEqual(list[1].OrderType.Order, orderedList[1].OrderType.Order);
        Assert.AreEqual(list[2].OrderType.Order, orderedList[2].OrderType.Order);
        Assert.AreEqual(list[0].OrderType.Order, orderedList[3].OrderType.Order);
    }

    [TestMethod]
    public void OrderWhenThenByTest()
    {
        var list = new List<Nested<int>>
        {
            new()
            {
                Name = "D",
                OrderType = new OrderType<int>
                {
                    Order = 2
                }
            },
            new()
            {
                Name = "B",
                OrderType = new OrderType<int>
                {
                    Order = 4
                }
            },
            new()
            {
                Name = "C",
                OrderType = new OrderType<int>
                {
                    Order = 8
                }
            },
            new()
            {
                Name = "A",
                OrderType = new OrderType<int>
                {
                    Order = 2
                }
            }
        };

        var ordering = new Ordering
        {
            By = "OrderType.Order",
            ThenBy = "Name",
            Direction = OrderingDirection.Asc
        };

        var orderedList = list
            .AsQueryable()
            .Order(ordering)
            .ToArray();

        Assert.AreEqual(list[0].Name, orderedList[1].Name);
        Assert.AreEqual(list[0].OrderType.Order, orderedList[1].OrderType.Order);
        Assert.AreEqual(list[1].Name, orderedList[2].Name);
        Assert.AreEqual(list[1].OrderType.Order, orderedList[2].OrderType.Order);
        Assert.AreEqual(list[2].Name, orderedList[3].Name);
        Assert.AreEqual(list[2].OrderType.Order, orderedList[3].OrderType.Order);
        Assert.AreEqual(list[3].Name, orderedList[0].Name);
        Assert.AreEqual(list[3].OrderType.Order, orderedList[0].OrderType.Order);
    }
}