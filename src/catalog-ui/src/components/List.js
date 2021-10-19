import React, { Component } from 'react';
import { Container } from 'reactstrap';

export class List extends Component {
  static displayName = List.name;

  render () {
    return (
      <div>
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
