import React, { Component, useState, useEffect } from 'react';
import "../styles/Login.css";
import "../styles/Btns.css";
import { apiPOST, apiGET } from '../functions/Api';
import { useHistory } from 'react-router-dom';

export default function Login(props) {

    const usernameRef = React.useRef();
    const passwordRef = React.useRef();
    const [loading, setLoading] = useState(true);
    const [user, setUser] = useState(null);
    const history = useHistory();

    const getOnlineUser = async function () {
        const response = await apiPOST('api/User/GetOnlineUser');

        if (response.success && response.data != null) {
            setUser({ username: response.data.username });
        }
        else {
            setUser(null);
        }
        setTimeout(() => setLoading(false), 1000);
    }

    const getOnlineUserHandler = function () {
        getOnlineUser();
    }

    useEffect(getOnlineUserHandler, []);

    const handleLogin = async function() {
        const username = usernameRef.current.value;
        const password = passwordRef.current.value;

        console.log(username);
        console.log(password);

        const loginResponse = await apiPOST('api/User/Login', { username: username, password: password });

        if (loginResponse.success) {
            setUser({ username: username })
            history.push("/");
        }
        else {
            alert(loginResponse.errorMessage);
        }
    }

    const handleLogout = async function () {
        const response = await apiGET('api/User/Logout');
        if (response.success) {
            setUser(null);
        }
        else {
            alert(response.errorMessage);
        }
    }

    const online = (
        <>
            <div>Welcome {user?.username}</div>
            <div><button onClick={handleLogout} className="btns" id="user-login-btn">Logout!</button></div>
        </>

    );

    const pending = (
        <div>
            LOADING ...
        </div>
    );

    const offline = (
        <div className="user-login-form" id="user-login-form">
            <h1>Login</h1>
            <div style={{ marginBottom: "60px" }}>
                <div className="form-title">Username</div>
                <div className="user-login-div"><input ref={usernameRef} className="login-input" type="text" id="user-login-username" /></div>
                <div className="form-title">Password</div>
                <div className="user-login-div"><input ref={passwordRef} className="login-input" type="password" id="user-login-password" /></div>
                <div style={{ marginTop: "20px" }}><button onClick={handleLogin} className="btns" id="user-login-btn">Login!</button></div>
            </div>
        </div>
    );

    const result = loading ? pending : (user ? online : offline);

    return result;
  }
