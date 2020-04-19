import React from 'react';
import PropTypes from 'prop-types';

import {Category} from './Category';

export class CategoryList extends React.Component {
    render() {
        const {categories} = this.props;

        return <div>
            {categories.map(x => 
                <Category 
                    key={x.id}
                    category={x} />)}
        </div>
    }
}

CategoryList.propTypes = {
    categories: PropTypes.array
};