import React from 'react'
import ItemListItem from './ItemListItem'

const ItemList = props => {
    const {items, clickItem, deleteItem, editItem} = props;
    return items.map(post => (
    <ItemListItem 
    key={items.id} 
    item={item} 
    clickItem={clickItem}
    deleteItem={deleteItem}
    editPost={editPost}/>
    ));
}
export default ItemList;