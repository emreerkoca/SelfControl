import React, { Component } from 'react';
import { Pagination, PaginationItem, PaginationLink } from 'reactstrap';
import authHeader from '../services/AuthHeader';
import { handleResponse } from '../helpers/handleResponse';
import UpdateWord from './UpdateWord';


export class GetWords extends Component {
  static displayName = GetWords.name;
  static requestOptions = {
    method: 'GET',
    headers: {
      'Authorization': authHeader()
    }
  };

  constructor(props) {
    super(props);

    this.currentPage = 1;
    this.pageSize = 10;
    this.pagesCount = this.getPageCount();

    this.state = { 
      error: null,
      isLoaded: false, 
      words: [], 
      word: {}, 
      viewState: false, 
      updateState: false, 
      deleteState: false,
      currentPage: 1 
    };
    
    this.getWords = this.getWords.bind(this);
    this.viewWord = this.viewWord.bind(this);
    this.updateWord = this.updateWord.bind(this);
    this.deleteWord = this.deleteWord.bind(this);
    this.getWord = this.getWord.bind(this);
    this.handlePaginationClick = this.handlePaginationClick.bind(this);
  }

  componentDidMount() {
    this.getWords();
  }

  getPageCount() {
    return 20;
  }

  getWords() {
    var requestUrl = 'word/get-words-by-range?pageIndex=' + this.currentPage + '&itemCount=10&userId=' + JSON.parse(localStorage.getItem('user-info') || '{}').userId;

    if (this.state.updateState || this.state.deleteState) {
      requestUrl += '&isUpdated=1'; 
    }
    
    fetch(requestUrl, GetWords.requestOptions)
      .then(handleResponse)
      .then(
          (result) => {
            this.setState({
              isLoaded: true,
              words: result,
              viewState: false,
              updateState: false,
              wordId: 0
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

  viewWord(wordId) {
    this.getWord(wordId);

    this.setState({
      viewState: true,
      updateState: false
    });
  }

  getWord(wordId) {
    fetch('word/get-word/' + wordId, GetWords.requestOptions)
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

  updateWord(wordId) {
    this.setState({
      viewState: false,
      updateState: true,
      wordId: wordId
    });
  }

  deleteWord(wordId) {
    const requestOptions = {
      method: 'DELETE',
      headers: {
        'Authorization': authHeader()
      }
    };

    fetch('word/delete-word/' + wordId, requestOptions)
      .then(handleResponse)
      .then(
          (result) => {
            this.setState({
              deleteState: true
            });

            this.getWords();
        },
        (error) => {
            console.log(error);
        }
      );
  }

  handlePaginationClick(e, index) {
    e.preventDefault();

    this.currentPage = index;
    this.getWords();
  }

  renderWordsTable(words) {
      return ( 
        <div>
        <table className='table table-striped' aria-labelledby="tabelLabel">
      <thead>
        <tr>
          <th>Word</th>
          <th>Meaning</th>
          <th>Example</th>
          <th>Operations</th>
        </tr>
      </thead>
      <tbody>
        {words.map(word =>
            <tr key={word.id}>
              <td>{word.vocable}</td>
              <td>{word.meaning}</td>
              <td>{word.sentence}</td>
              <td>{<button className="btn btn-warning" onClick={this.viewWord.bind(this, word.id)}>View</button>}</td>
              <td>{<button className="btn btn-secondary" onClick={this.updateWord.bind(this, word.id)}>Edit</button>}</td>
              <td>{<button className="btn btn-danger" onClick={this.deleteWord.bind(this, word.id)}>Delete</button>}</td>
            </tr>
        )}
      </tbody>
    </table>
    <Pagination>
            <PaginationItem disabled={this.currentPage <= 0}>
              <PaginationLink
                onClick={e => this.handlePaginationClick(e, this.currentPage - 1)}
                previous
                href="#"
              />
            </PaginationItem>

            {[...Array(this.pagesCount)].map((page, i) => 
              <PaginationItem active={i === this.currentPage - 1} key={i}>
                <PaginationLink onClick={e => this.handlePaginationClick(e, i + 1)} href="#">
                  {i + 1}
                </PaginationLink>
              </PaginationItem>
            )}

            <PaginationItem disabled={this.currentPage >= this.pagesCount - 1}>
              <PaginationLink
                onClick={e => this.handlePaginationClick(e, this.currentPage + 1)}
                next
                href="#"
              />
            </PaginationItem>
          </Pagination>
    </div>
    );
  }

  render() {
    const { error, isLoaded, words, word, wordId, viewState, updateState } = this.state;  

    if (error) {
      return <div>Error: {error.message}</div>;
    } else if (!isLoaded) {
      return <div>Loading...</div>;
    } else { 
      if (!viewState && !updateState) {
        return (
          <div>
            { this.renderWordsTable(words) }
          </div>
        );
      }  else if (viewState) {
        return (
          <div>
              <p>{word.vocable}</p>
              <p>{word.meaning}</p>
              <p>{word.sentence}</p>
              <button className="btn btn-info" onClick={this.getWords}>Back To Words</button>
          </div>
        );
      } else if (updateState) {
        return (
          <UpdateWord wordId={wordId} handleGetWords={this.getWords}></UpdateWord>
        );
      }
      
    }
  }
}