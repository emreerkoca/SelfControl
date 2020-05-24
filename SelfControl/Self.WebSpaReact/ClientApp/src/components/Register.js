import React, { Component } from "react";
import Form from "react-validation/build/form";
import Input from "react-validation/build/input";
import CheckButton from "react-validation/build/button";

import { isEmail } from "validator";
import AuthService from "../services/auth.service"; 

const requiredValidation = value => {
    if (!value) {
      return (
        <div className="alert alert-danger" role="alert">
          This field is required!
        </div>
      );
    }
};
  
const emailValidation = value => {
    if (!isEmail(value)) {
        return (
        <div className="alert alert-danger" role="alert">
            This is not a valid email.
        </div>
        );
    }
};

const passwordValidation = value => {
    if (value.length < 6 || value.length > 28) {
        return (
        <div className="alert alert-danger" role="alert">
            The password must be between 6 and 28 characters.
        </div>
        );
    }
};

export class Register extends Component {
    constructor(props) {
        super(props);

        this.handleRegister = this.handleRegister.bind(this);
        this.onChangeFirstName = this.onChangeFirstName.bind(this);
        this.onChangeLastName = this.onChangeLastName.bind(this);
        this.onChangeEMail = this.onChangeEMail.bind(this);
        this.onChangePassword = this.onChangePassword.bind(this);

        this.state = {
            firstName: '',
            lastName: '',
            email: '',
            password: '',
            successful: false,
            message: ''
        };
    }

    onChangeFirstName(e) {
        this.setState({
            firstName: e.target.value
        });
    }

    onChangeLastName(e) {
        this.setState({
            lastName: e.target.value
        })
    }

    onChangeEMail(e) {
        this.setState({
            email: e.target.value
        });
    }

    onChangePassword(e) {
        this.setState({
            password: e.target.value
        });
    }

    handleRegister(e) {
        e.preventDefault();

        this.setState({
            message: "",
            loading: true
        });

        this.form.validateAll();

        if (this.checkButton.context._errors.length === 0) {
            var user = {
                firstName: this.state.firstName,
                lastName: this.state.lastName,
                email: this.state.email,
                password: this.state.password
            };

            AuthService.signup(user).then(
                response => {
                    this.setState({
                        message: response,
                        successful: true
                    });
                },
                error => {
                    const responseMessage =
                    (error.response &&
                      error.response.data &&
                      error.response.data.message) ||
                    error.message ||
                    error.toString(); 

                    this.setState({
                        successful: false,
                        message: error
                    });
                }
            );
        }
    }

    render() {
        return (
             <div className="col-md-12">
                 <div class="card card-container">
                    <Form
                        onSubmit={this.handleRegister}
                        ref={c => {
                        this.form = c;
                        }}
                    >
                        {!this.state.successful && (
                        <div>
                            <img
                                src="//ssl.gstatic.com/accounts/ui/avatar_2x.png"
                                alt="profile-img"
                                className="profile-img-card"
                            />
                            <div className="form-group">
                                <label htmlFor="firstName">First Name</label>
                                <Input
                                    type="text"
                                    className="form-control"
                                    name="firstName"
                                    value={this.state.firstName}
                                    onChange={this.onChangeFirstName}
                                    validations={[requiredValidation]}
                                />
                            </div>
                            <div className="form-group">
                                <label htmlFor="lastName">Last Name</label>
                                <Input
                                    type="text"
                                    className="form-control"
                                    name="lastName"
                                    value={this.state.lastName}
                                    onChange={this.onChangeLastName}
                                    validations={[requiredValidation]}
                                />
                            </div>
                            <div className="form-group">
                                <label htmlFor="email">Email</label>
                                <Input
                                    type="text"
                                    className="form-control"
                                    name="email"
                                    value={this.state.email}
                                    onChange={this.onChangeEMail}
                                    validations={[requiredValidation, emailValidation]}
                                />
                            </div>
                            <div className="form-group">
                                <label htmlFor="password">Password</label>
                                <Input
                                    type="password"
                                    className="form-control"
                                    name="password"
                                    value={this.state.password}
                                    onChange={this.onChangePassword}
                                    validations={[requiredValidation, passwordValidation]}
                                />
                            </div>
                            <div className="form-group">
                                <button className="btn btn-primary btn-block">Sign Up</button>
                            </div>
                        </div>
                        )}

                        {this.state.message && (
                        <div className="form-group">
                            <div
                                className={
                                    this.state.successful
                                    ? "alert alert-success"
                                    : "alert alert-danger"
                                }
                                role="alert"
                                >
                                {this.state.message}
                            </div>
                        </div>
                        )}
                        <CheckButton
                        style={{ display: "none" }}
                        ref={c => {
                            this.checkButton = c;
                        }}
                        />
                    </Form>
                </div>
            </div>
        );
    }
}