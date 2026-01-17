using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Highest priority item dequeued first
    // Expected Result: Item with highest priority returned
    // Defect(s) Found: Highest priority not always selected
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 10);
        pq.Enqueue("Medium", 5);

        Assert.AreEqual("High", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: FIFO when priorities are equal
    // Expected Result: Items removed in insertion order
    // Defect(s) Found: FIFO broken due to >= comparison
    public void TestPriorityQueue_FIFOEqualPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 5);
        pq.Enqueue("Second", 5);
        pq.Enqueue("Third", 5);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException thrown
    // Defect(s) Found: None
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}
