# DateGreaterThanDirective.coffee
# @author: Ricardo Barreno Cortijo <rickraf.01@gmail.com>

###
abastecimiento.directive "dateGreatherThan", ["$filter", ($filter) ->
    {
        require: "ngModel"
        link: (scope, elm, attrs, ctrl) ->
            var validateDateRange = (inputValue) ->
                fromDate = $filter("date")(attrs.dateGreaterThan, "short")
                toDate = $filter("date")(inputValue, "short")
                ctrl.$setValidity('dateGreaterThan', isValid);
                inputValue;
            return
    }
]

return {
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {            
            var validateDateRange = function (inputValue) {
                var fromDate = $filter('date')(attrs.dateGreaterThan, 'short');
                var toDate = $filter('date')(inputValue, 'short');
                var isValid = isValidDateRange(fromDate, toDate);
                ctrl.$setValidity('dateGreaterThan', isValid);
                return inputValue;
            };

            ctrl.$parsers.unshift(validateDateRange);
            ctrl.$formatters.push(validateDateRange);
            attrs.$observe('dateGreaterThan', function () {
                validateDateRange(ctrl.$viewValue);

            });
        }
    };###