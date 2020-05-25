import React, { Component } from "react";

export class LogOut extends Component {
    componentWillMount() {
        this.props.handleLogout();

        this.props.history.push('/');
    }

    render() {
        return null
    }
}