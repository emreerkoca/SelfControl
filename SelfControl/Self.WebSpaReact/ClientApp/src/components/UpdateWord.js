import React, { Component } from 'react';
import { Button } from 'react-bootstrap';
import authHeader from '../services/AuthHeader';
import { handleResponse } from '../helpers/handleResponse';

export default class UpdateWord extends React.Component {
    static requestOptions = {
        method: 'GET',
        headers: {
          'Authorization': authHeader()
        }
    };

    constructor(props) {
        super(props);

        this.state = {
            isLoaded: false,
            error: null,
            word: {
                id: '',
                vocable: '',
                meaning: '',
                sentence: '',
                ownerId: JSON.parse(localStorage.getItem('user-info') || '{}').userId,
                viewCount: 0
            }
        };
    
        this.handleGetWords = this.handleGetWords.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleWordChange = this.handleWordChange.bind(this);
        this.handleMeaningChange = this.handleMeaningChange.bind(this);
        this.handleExampleChange = this.handleExampleChange.bind(this);
    }

    componentDidMount() {
       fetch('word/get-word/' + this.props.wordId, UpdateWord.requestOptions)
        .then(handleResponse)
        .then(
            (result) => {
                this.setState({
                isLoaded: true,
                word: result
                });
            },
            (error) => {
                this.setState({
                isLoaded: true,
                error
                });
            }
       );
    }

    handleGetWords() {
        this.props.handleGetWords();
    }

    handleWordChange(e) {
        this.setState({
            word: {
                id: this.state.word.id,
                vocable: e.target.value,
                meaning: this.state.word.meaning,
                sentence: this.state.word.sentence,
                ownerId: JSON.parse(localStorage.getItem('user-info') || '{}').userId,
                viewCount: 0
            }
        });
    }
    
    handleMeaningChange(e) {
        this.setState({
            word: {
                id: this.state.word.id,
                vocable: this.state.word.vocable,
                meaning: e.target.value,
                sentence: this.state.word.sentence,
                ownerId: JSON.parse(localStorage.getItem('user-info') || '{}').userId,
                viewCount: 0
            }
        });
    }
  
    handleExampleChange(e) {
        this.setState({sentence: e.target.value});
        this.setState({
            word: {
                id: this.state.word.id,
                vocable: this.state.word.vocable,
                meaning: this.state.word.meaning,
                sentence: e.target.value,
                ownerId: JSON.parse(localStorage.getItem('user-info') || '{}').userId,
                viewCount: 0
            }
        });
    }
    
    handleSubmit(event) {
        event.preventDefault();

        const requestOptions = {
            method: 'PUT',
            headers: {
              'Authorization': authHeader(),
              'Accept': 'application/json',
              'Content-Type': 'application/json',
            },
            body: JSON.stringify(this.state.word)
          };
    
          fetch('/word/update-word/' + this.props.wordId, requestOptions)
            .then(handleResponse)
            .then(
                (result) => {
                    alert('Word updated');
                },
              (error) => {
                  console.log(error);
              }
            );
    }

    render() {
        const { isLoaded, error, word } = this.state; 

        if (isLoaded && !error) {
            return (
                <div>
                    <form onSubmit={this.handleSubmit} >
                    <div className="form-element">
                    <input type="text" id="word" value={word.vocable} 
                        onChange={this.handleWordChange} className="col-md-3 col-xs-12" placeholder="Word"/>
                    </div>
                    <div className="form-element">
                    <textarea type="text" id="meaning" value={word.meaning} 
                        onChange={this.handleMeaningChange} className="col-md-3 col-xs-12" placeholder="Meaning" />
                    </div>
                    <div className="form-element">
                    <textarea type="text" id="example" value={word.sentence} 
                        onChange={this.handleExampleChange} className="col-md-3 col-xs-12" placeholder="Example Sentence" />
                    </div>
                    <div className="col-md-3">
                    <div className="form-actions row">
                    <Button onClick={this.handleGetWords} variant="warning" className="col-md-6 col-xs-3">Back to Words</Button>
                    <input type="submit" id="submit" className="btn btn-primary col-md-6 col-xs-3" value="Update"/>
                    </div>
                    </div>
                </form>
                </div> 
            );
        } else if (isLoaded && error) {
            return (
                error
            );
        }
        else {
            return null;
        }
        
    }
}