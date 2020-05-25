import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

import AuthService from '../services/auth.service';

export class PrivateNavMenu extends Component {
  static displayName = PrivateNavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  // logOut() {
  //   AuthService.logout();
  // }

  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/">Learn a Language</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                {
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/add-word">Add Word</NavLink>
                  </NavItem>
                }
                {
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/get-words">My Vocabulary</NavLink>
                  </NavItem>
                }
                {
                  <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/logout">LogOut</NavLink>
                  </NavItem>
                }
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
