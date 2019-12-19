import React from 'react';
import {useHistory} from 'react-router-dom';
import slugify from 'slugify';
import './styles.css';

const ItemListItem = props =>{
    const{item, clickItem, deleteItem, editItem} = props;
    const history = useHistory();
    const handleClickItem= item => {
        const slug = slugify(item.title, {lower: true});
        clickItem(item);
        history.push(`/items/${slug}`);
    };
    const handleEditItem = item =>{
        editItem(item);
        history.push(`edit-item/${item.id}`);
    }
    return (
        <div>
            <div className="itemListItem" onClick={() => handleClickItem(item)}>
                <h2>{item.title}</h2>
                <p>{item.body}</p>
            </div>
            <div className="itemControls">
                <button onClick={() => deleteItem(item)}>Delete</button>
                <button onClick={() => handleEditItem(item)}>Edit</button>
            </div>
        </div>
    );
};
export default ItemListItem;