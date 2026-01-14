using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and dequeue them
    // Test basic enqueue/dequeue functionality with varying priorities
    // Expected Result: Items should be returned in order of highest priority first
    // Defect(s) Found: Dequeue method did not remove items from the queue, only returned them. Also, loop condition was "index < _queue.Count - 1" which skipped the last item.
    public void TestPriorityQueue_BasicPriorityOrdering()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("medium", 3);

        Assert.AreEqual("high", priorityQueue.Dequeue(), "Item with priority 5 should be dequeued first");
        Assert.AreEqual("medium", priorityQueue.Dequeue(), "Item with priority 3 should be dequeued second");
        Assert.AreEqual("low", priorityQueue.Dequeue(), "Item with priority 1 should be dequeued last");
    }

    [TestMethod]
    // Scenario: Add items with same priority and verify FIFO order
    // Multiple items with the same high priority should follow FIFO (first in, first out)
    // Expected Result: First item added with that priority should be removed first
    // Defect(s) Found: Loop condition "index < _queue.Count - 1" caused it to skip checking the last item. Also no item removal was happening.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 3);
        priorityQueue.Enqueue("third", 5);

        Assert.AreEqual("first", priorityQueue.Dequeue(), "First item with priority 5 should be dequeued first (FIFO)");
        Assert.AreEqual("third", priorityQueue.Dequeue(), "Third item with priority 5 should be dequeued second");
        Assert.AreEqual("second", priorityQueue.Dequeue(), "Item with priority 3 should be dequeued last");
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None found - error handling works correctly.
    public void TestPriorityQueue_EmptyQueueException()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown for empty queue.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                              e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Complex scenario with multiple items at various priorities
    // Enqueue items at different priorities and verify correct dequeue order
    // Expected Result: Items should be dequeued in priority order (highest first), with FIFO for same priority
    // Defect(s) Found: Dequeue method did not remove items from the queue and had incorrect loop bounds.
    public void TestPriorityQueue_ComplexOrdering()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("item1", 2);
        priorityQueue.Enqueue("item2", 5);
        priorityQueue.Enqueue("item3", 2);
        priorityQueue.Enqueue("item4", 5);
        priorityQueue.Enqueue("item5", 1);

        Assert.AreEqual("item2", priorityQueue.Dequeue(), "Priority 5, first added");
        Assert.AreEqual("item4", priorityQueue.Dequeue(), "Priority 5, second added");
        Assert.AreEqual("item1", priorityQueue.Dequeue(), "Priority 2, first added");
        Assert.AreEqual("item3", priorityQueue.Dequeue(), "Priority 2, second added");
        Assert.AreEqual("item5", priorityQueue.Dequeue(), "Priority 1, last added");
    }
}
