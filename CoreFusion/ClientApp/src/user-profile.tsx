import React from 'react'
import ReactDOM from 'react-dom/client'

//グローバル変数の型定義を拡張(tsconfig.jsonでglobal.d.tsなどを設定するのが望ましい)
declare global {
    interface Window {
        APP_INITIAL_DATA?: {
            Id: string;
            Name: string;
            IsAddmin: boolean;
        }
    }
}

interface UserProfileProps {
    id: string;
    name: string;
}

export const UserProfile: React.FC<UserProfileProps> = ({ id, name }) => {
    return (
        <div>
            <h3>ユーザープロフィール</h3>
            <p>ID：{id}</p>
            <p>名前：{ name }</p>
        </div>
    );
};

const userProfileElement = document.getElementById('user-profile-root');


if (userProfileElement && window.APP_INITIAL_DATA) {
    const { Id, Name } = window.APP_INITIAL_DATA;
    const root = ReactDOM.createRoot(userProfileElement);
    root.render(
        <React.StrictMode>
            <UserProfile id={Id} name={ Name } />
        </React.StrictMode>
    )

}
