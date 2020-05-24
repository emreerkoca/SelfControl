import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { PublicNavMenu } from './PublicNavMenu';


export class PublicLayout extends Component {
  static displayName = PublicLayout.name;

  render () {
    return (
      <div>
         <PublicNavMenu />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
