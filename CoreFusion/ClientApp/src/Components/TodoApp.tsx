import React, { useState, useEffect } from 'react';

//TodoItemの型定義（バックエンドのモデルと一致させる）
interface TodoItem {
    id: number;
    title: string;
    isCompleted: boolean;
}

const TodoApp: React.FC = () => {
    const [todos, setTodos] = useState<TodoItem[]>([]);
    const [newTodoTitle, setNewTodoTItle] = useState<string>('');
    const API_BASE_URL = '/api/TodoItems'; // ASP.NET Core APIのURL

    //コンポーネントからマウントされた時にTodoアイテムをフェッチ
    useEffect(() => {
        fetchTodos();
    }, []);

    //ASP.NET CoreからTodoアイテムを呼び出し
    const fetchTodos = async () => {
        try {
            const response = await fetch(API_BASE_URL);
            if (!response.ok) {
                throw new Error(`HTTP error!： ${response.status}`);
            }

            const data: TodoItem[] = await response.json();
            setTodos(data);
        } catch (error) {
            console.error("Error fetching todos:",error);
        }
    }

    //TodoアイテムをASP.NET Coreに追加
    const addTodo = async() => {
        if (!newTodoTitle.trim()) return;

        try {
            const response = await fetch(API_BASE_URL, {
                method: 'POST',
                headers: {
                    'content-Type': 'application/json',
                },
                body: JSON.stringify({ title: newTodoTitle, isCompleted: false }),
            });

            if (!response.ok) {
                throw new Error(`HTTP error! status：${response.status}`);
            } 

            const newTodo: TodoItem = await response.json();
            setTodos(preTodos => [...preTodos,newTodo])
            setNewTodoTItle('') //入力フィールドをクリア
        } catch (error) {
            console.error("Error adding todo：", error);

        }
    }

    //Todoアイテムを更新する
    const toggleTodoCompletion = async (id: number, isCompleted:boolean) => {
        const todoToUpdate = todos.find(todo => todo.id == id);
        if (!todoToUpdate) return;

        try {
            const updatedTodo = { ...todoToUpdate, isCompleted: !isCompleted };
            const response = await fetch(`${API_BASE_URL}/${id}`, {
                method: 'PUT',
                headers: {
                    'content-Type': 'application/json',
                },
                body: JSON.stringify(updatedTodo),
            });

            if (!response.ok) {
                throw new Error(`HTTP error! status：${response.status}`);
            }
            setTodos(preTodos =>
                preTodos.map(todo =>
                    todo.id === id ? {... todo, isCompleted: !isCompleted} : todo
                )
            );
        } catch (error) {
            console.error("Error updating todo：",error)
        }

    }

    //Todoアイテムを削除する
    const deleteTodo = async (id: number) => {
        try {
            const response = await fetch(`${API_BASE_URL}/${id}`, {
                method: 'DELETE'
            });

            if (!response.ok) {
                throw new Error(`HTTP error! status：${response.status}`);
            }

            setTodos(preTodos => preTodos.filter(todo => todo.id !== id));

        }catch(error){
            console.error("Error deleting todo：",error)
        }
    }

    return (
        <div>
            <h1>Todo List</h1>
            <div>
                <input type="text" value={newTodoTitle} onChange={(e) => setNewTodoTItle(e.target.value) } placeholder="Add new todo" />
                <button onClick={addTodo }>Add Todo</button>
            </div>
            <ul>
                {todos.map((todo) => (
                    <li key={ todo.id}>
                        <input type="checkbox" checked={todo.isCompleted} onChange={ () => toggleTodoCompletion(todo.id,todo.isCompleted) } />
                        <span style={{ textDecoration: todo.isCompleted ? 'line-through' : 'none' }}>{todo.title}</span>
                        <button onClick={() => deleteTodo(todo.id) }>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default TodoApp;