Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports ToDo

Namespace Controllers
    Public Class ToDoesController
        Inherits System.Web.Mvc.Controller

        Private db As New ToDo_dbEntities1

        ' GET: ToDoes
        Function Index() As ActionResult
            Return View(db.ToDo.ToList())
        End Function

        ' GET: ToDoes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim toDo As ToDo = db.ToDo.Find(id)
            If IsNothing(toDo) Then
                Return HttpNotFound()
            End If
            Return View(toDo)
        End Function

        ' GET: ToDoes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: ToDoes/Create
        'Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        'plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,ToDoItem,IsDone")> ByVal toDo As ToDo) As ActionResult
            If ModelState.IsValid Then
                db.ToDo.Add(toDo)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(toDo)
        End Function

        ' GET: ToDoes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim toDo As ToDo = db.ToDo.Find(id)
            If IsNothing(toDo) Then
                Return HttpNotFound()
            End If
            Return View(toDo)
        End Function

        ' POST: ToDoes/Edit/5
        'Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        'plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,ToDoItem,IsDone")> ByVal toDo As ToDo) As ActionResult
            If ModelState.IsValid Then
                db.Entry(toDo).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(toDo)
        End Function

        ' GET: ToDoes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim toDo As ToDo = db.ToDo.Find(id)
            If IsNothing(toDo) Then
                Return HttpNotFound()
            End If
            Return View(toDo)
        End Function

        ' POST: ToDoes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim toDo As ToDo = db.ToDo.Find(id)
            db.ToDo.Remove(toDo)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
