using System.Collections.Generic;

public class MementoManager
{
    private readonly Stack<BoardMemento> _undoStack = new();
    private readonly Stack<BoardMemento> _redoStack = new();

    public void Record(BoardMemento memento)
    {
        _undoStack.Push(memento);
        _redoStack.Clear();
    }

    public BoardMemento Undo(BoardMemento current)
    {
        if (_undoStack.Count == 0) return current;

        _redoStack.Push(current);
        return _undoStack.Pop();
    }

    public BoardMemento Redo(BoardMemento current)
    {
        if (_redoStack.Count == 0) return current;

        _undoStack.Push(current);
        return _redoStack.Pop();
    }

    public void Clear()
    {
        _undoStack.Clear();
        _redoStack.Clear();
    }
}