@ModelType ToDo.ToDo
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>ToDo</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.ToDoItem)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ToDoItem)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsDone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsDone)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
