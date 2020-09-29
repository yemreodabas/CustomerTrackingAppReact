import React, { Component } from 'react';

export default class UserSelect extends Component {
    constructor(props) {
        super(props);
        this.addNewUser = this.addNewUser.bind(this);
        this.handleNewUsernameChange = this.handleNewUsernameChange.bind(this);

        this.state = { users: [], newUsername: '' };
    }

    componentDidMount() {
        this.getUsersFromDB();
    }

    async getUsersFromDB() {
        const response = await fetch('api/User/GetUsers');
        const data = await response.json();
        this.setState({ users: data });
    }

    addNewUser() {
        //const users = this.state.users;
        //users.push(this.state.newUsername);
        //this.setState({ users, newUsername: '' });

        this.addUserToDB(this.state.newUsername);
    }

    async addUserToDB(username) {
        const response = await fetch('api/User/AddUser', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ Username: username })
        });

        const data = await response.json();
        this.setState({ users: data, newUsername: '' });
    }

    handleNewUsernameChange(e) {
        this.setState({ newUsername: e.target.value });
    }

    render() {
        const users = this.state.users;

        return (
            <div>
                <div>{this.props.title}</div>
                <div>
                    <select>
                        {users.map((username, b) =>
                            <option value={b}>{username}</option>
                        )}
                    </select>
                </div>
                <div>
                    <input type="text" onChange={this.handleNewUsernameChange} value={this.state.newUsername} />
                </div>
                <div>
                    <button onClick={this.addNewUser}>EKLE</button>
                </div>
            </div>
        );
    }
}
