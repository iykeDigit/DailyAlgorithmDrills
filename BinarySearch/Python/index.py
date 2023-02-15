def locate_cards(cards, query):
    low = 0
    high = len(cards)-1
    while low <= high:
        mid = high+low//2
        if query == cards[mid]:
            return mid
        if query < cards[mid]:
            low = mid+1
        else:
            high = mid-1
    return -1


cards = [9, 7, 6, 5, 4, 3, 2, 1]
print(locate_cards(cards, 1))
