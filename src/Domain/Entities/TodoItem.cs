﻿namespace CleanArchitecture.Domain.Entities;

public class TodoItem : BaseAuditableEntity
{
    public int ListId { get; set; }

    [MaxLength(200)]
    public string Title { get; set; } = default!;

    public string? Note { get; set; }

    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    private bool _done;
    public bool Done
    {
        get => _done;
        set
        {
            if (value && !_done)
            {
                AddDomainEvent(new TodoItemCompletedEvent(this));
            }

            _done = value;
        }
    }

    public TodoList List { get; set; } = null!;
}
