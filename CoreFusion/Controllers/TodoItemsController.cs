using CoreFusion.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreFusion.Controllers
{
    [ApiController] //これがAPIコントローラーであることを示す
    [Route("api/[controller]")] //ルーティングパスを定義
    public class TodoItemsController : ControllerBase　//Viewを持たないのでControllerBaseを継承
    {
        //簡易的なデータストアとしてリストを使用
        private static List<TodoItem> _todoItems = new List<TodoItem>
        {
            new TodoItem{ Id = 1, Title  = "Learn React Basics", IsCompleted = false},
            new TodoItem{ Id = 2, Title = "Build ASP.NET Core API", IsCompleted = false},
            new TodoItem{ Id = 3, Title = "Connect Front-end & Back-end", IsCompleted = false}
        };

        private static int _nextId = _todoItems.Max(t => t.Id) + 1; //新しいID生成用

        //GET: api/TodoItem
        [HttpGet] // HTTP GETリクエスト対応
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            return Ok(_todoItems); //200 OKとアイテムのリストをJSONで返す
        }

        //GET： api/TodoItems/5
        [HttpGet("{id}")] //HTTP GETリクエスト、IDを指定するパスに対応
        public ActionResult<TodoItem> GetTodoItems(int id)
        {
            var todoItem = _todoItems.FirstOrDefault(t => t.Id == id);

            if ((todoItem == null))
            {
                return NotFound();
            }

            return Ok(todoItem); //200としていされたTodoアイテムをJSONで返す

        }

        //POST： api/TodoItems
        [HttpPost] //HTTP POSTリクエストに対応
        public ActionResult<TodoItem> ProstTodoItem(TodoItem todoItem)
        {
            todoItem.Id = _nextId; // 新しいIDを割り当てる
            _todoItems.Add(todoItem);
            //201 Createdと、作成されたTodoアイテム、およびそのアイテムへのURLを返す
            return CreatedAtAction(nameof(GetTodoItems), new { id = todoItem.Id }, todoItem);
        }

        //PUT： api/TodoItem/5
        [HttpPut("{id}")] //HTTP PUT リクエストに対応
        public IActionResult PutTodoItem(int id, TodoItem todoItem)
        {
            if(id != todoItem.Id)
            {
                return BadRequest(); //400 Bad Request
            }

            var existingTodo = _todoItems.First(t => t.Id == id);
            if(existingTodo == null)
            {
                return NotFound(); //404 Not Found
            }

            existingTodo.Title = todoItem.Title;
            existingTodo.IsCompleted = todoItem.IsCompleted;

            return NoContent(); //204 No Content （更新成功）
        }

        //DELETE： api/TodoItems/5
        [HttpDelete("{id}")] // HTTP DELETE リクエストに対応
        public IActionResult DeleteTodoItem(int id)
        {
            var todoItem = _todoItems.FirstOrDefault(t => t.Id == id);
            if(todoItem == null)
            {
                return NotFound(); // 404 Not Found
            }

            _todoItems.Remove(todoItem);
            return NoContent(); // 204 No Content (削除成功)
        }

        
    }
}
