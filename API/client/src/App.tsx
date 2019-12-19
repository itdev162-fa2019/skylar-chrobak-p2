import React from 'react';
import axios from 'axios';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import ItemList from './components/ItemList/ItemList';
import Item from './components/Item/Item';
import CreateItem from './components/Item/CreateItem';
import EditItem from './components/Item/EditItem';
import './App.css';

class App extends React.Component {
  state= {
    items: [],
    item: null
  }
  componentDidMount() {
    axios.get('http://localhost:5000/api/items').then((response) => {
      this.setState({
        items: response.data
      })
    })
    .catch((error) => {
      console.error(`Error fetching data: ${error}`);
    })
  }
  viewItem=(item) =>{
    console.log(`view ${item.title}`);
    this.setState({
      item: item
    });
  }
  deleteItem = item =>{
    axios.delete('http://localhost:5000/api/items/${post.id}').then(response=>{
      const newItems = this.state.items.filter(i => i.id !== item.id);
      this.setState({items: [...newItems]});
    }).catch(error =>{
      console.error(`Error deleting item: ${error}`);
    });
  }
  editItem = item =>{
    this.setState({
      item: item
    });
  };
  onItemCreated = item =>{
    const newItems = [...this.state.items, item];
    this.setState({ items: newItems});
  };
  onItemUpdated= item => {
    console.log('updated item: ', item);
    const newItems = [...this.state.items];
    const index = newItems.findIndex(i => i.id === item.id);
    newItems[index]=item;
    this.setState({
      items:newItems
    });
  };
  render(){
    const{items, item} = this.state;
    return(
      <Router>
        <div className="App">
          <header className="App-Header">ShoppingList</header>
          <nav>
            <Link to="/">Home</Link>
            <Link to="/new-item">New Item</Link>
          </nav>
          <main className="App-Content">
            <switch>
              <Route exact path ="/">
                <ItemList 
                items={items} 
                clickItem={this.viewItem}
                deleteItem={this.deleteItem}
                editItem={this.editItem}/>
              </Route>
              <Route path="/items:itemId">
                <Item item={item}/>
              </Route>
              <Route path="/new-item">
                <CreateItem onItemCreated={this.onItemCreated}/>
              </Route>
              <Route path="/edit-item/:itemId">
                <EditItem item={item} onItemUpdated={this.onItemUpdated}/>
              </Route>
            </switch>
          </main>
        </div>
      </Router>
    );
  }
}
export default App;
