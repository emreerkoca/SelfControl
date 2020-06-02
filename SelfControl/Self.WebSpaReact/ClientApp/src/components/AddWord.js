import React, { Component } from 'react';
import { Button } from 'react-bootstrap';
import authHeader from '../services/AuthHeader';
import { handleResponse } from '../helpers/handleResponse';

export class AddWord extends Component {
    constructor(props) {
      super(props);
      this.state = { 
        vocable: '',
        meaning: '',
        sentence: '',
        ownerId: JSON.parse(localStorage.getItem('user-info') || '{}').userId,
        viewCount: 0
      };

      this.handleSubmit = this.handleSubmit.bind(this);
      this.handleWordChange = this.handleWordChange.bind(this);
      this.handleMeaningChange = this.handleMeaningChange.bind(this);
      this.handleExampleChange = this.handleExampleChange.bind(this);
    }

    handleWordChange(e) {
      this.setState({vocable: e.target.value});
    }
  
    handleMeaningChange(e) {
      this.setState({meaning: e.target.value});
    }

    handleExampleChange(e) {
      this.setState({sentence: e.target.value});
    }

   static clearForm ()  {
      document.querySelector('#word').value = '';
      document.querySelector('#meaning').value = '';
      document.querySelector('#example').value = '';
    }

    handleSubmit(e) {
      e.preventDefault();
      const requestOptions = {
        method: 'POST',
        headers: {
          'Authorization': authHeader(),
          'Accept': 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.state)
      };

      fetch('/word/add-word', requestOptions)
        .then(handleResponse)
        .then(
            (result) => {
              AddWord.clearForm();
          },
          (error) => {
              console.log(error);
          }
        );
  }

  
    render() {
      return (
          <form onSubmit={this.handleSubmit} >
        <div className="form-element">
          <input type="text" id="word" value={this.state.vocable} 
          onChange={this.handleWordChange} className="col-md-3 col-xs-12" placeholder="Word"/>
        </div>
        <div className="form-element">
          <textarea type="text" id="meaning" value={this.state.meaning} 
          onChange={this.handleMeaningChange} className="col-md-3 col-xs-12" placeholder="Meaning" />
        </div>
        <div className="form-element">
          <textarea type="text" id="example" value={this.state.sentence} 
          onChange={this.handleExampleChange} className="col-md-3 col-xs-12" placeholder="Example Sentence" />
        </div>
        <div className="col-md-3">
        <div className="form-actions row">
          <Button variant="warning" className="col-md-6 col-xs-3">Cancel</Button>{' '}
          <input type="submit" id="submit" className="btn btn-primary col-md-6 col-xs-3" value="Add"/>
        </div>
        </div>
      </form>
      );
    }
  }