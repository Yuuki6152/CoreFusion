import React from "react";
import ReactDOM from "react-dom/client";
import TodoApp from "./Components/TodoApp";

const todoElement = document.getElementById('todo-root')
if (todoElement) {
    const root = ReactDOM.createRoot(todoElement);
    root.render(
        <React.StrictMode>
            <TodoApp />
        </React.StrictMode>
    )
}